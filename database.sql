-- DUMMY DATA // Update line 9 owner id based on own table

INSERT INTO "PetOwners" ("owner_name", "email", "pet_number")
VALUES
('Frank Zappa', 'frank@zappamusic.org', '0');

INSERT INTO "Pets" ("pet_name", "breed", "color", "checkedInAT", "petOwnerid")
VALUES
('Fido', 3, 1, '2020-07-21T03:35:23.880902Z', [UPDATE THIS]);